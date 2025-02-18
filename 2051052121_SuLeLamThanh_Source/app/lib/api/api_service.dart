import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:logger/logger.dart';

import '../models/species.dart';
import '../models/statistics.dart';

const String baseUrl = 'http://10.0.2.2:8080/api';

class ApiService {
  static final Logger logger = Logger();

  static Future<Map<String, dynamic>> fetchFilteredData({
    String? searchText,
    int? selectedOrganismGroup,
    int? selectedConservationStatus,
    int pageNumber = 1,
    int pageSize = 10,
    String? scientificName,
    String? commonName,
    int? kingdomId,
    int? phylumId,
    int? classId,
    int? orderId,
    int? familyId,
    int? genusId,
    int? organismGroupId,
    int? conservationStatusId,
    String? authorName,
    String? researchRecordNote,
    bool? isEndemic,
    bool? isNonEndemic,
  }) async {
    final Uri uri = Uri.parse('$baseUrl/Species/filter').replace(queryParameters: {
      if (scientificName != null) 'scientificName': scientificName,
      if (commonName != null) 'commonName': commonName,
      if (kingdomId != null) 'kingdomId': kingdomId.toString(),
      if (phylumId != null) 'phylumId': phylumId.toString(),
      if (classId != null) 'classId': classId.toString(),
      if (orderId != null) 'orderId': orderId.toString(),
      if (familyId != null) 'familyId': familyId.toString(),
      if (genusId != null) 'genusId': genusId.toString(),
      if (organismGroupId != null) 'organismGroupId': organismGroupId.toString(),
      if (conservationStatusId != null) 'conservationStatusId': conservationStatusId.toString(),
      if (authorName != null) 'authorName': authorName,
      if (researchRecordNote != null) 'researchRecordNote': researchRecordNote,
      if (isEndemic != null) 'isEndemic': isEndemic.toString(),
      if (isNonEndemic != null) 'isNonEndemic': isNonEndemic.toString(),
      'pageNumber': pageNumber.toString(),
      'pageSize': pageSize.toString(),
      if (searchText != null && searchText.isNotEmpty) 'search': searchText,
      if (selectedOrganismGroup != null) 'organism_group': selectedOrganismGroup.toString(),
      if (selectedConservationStatus != null) 'conservation_status': selectedConservationStatus.toString(),
    });

    try {
      final response = await http.get(
        uri,
        headers: {
          'Content-Type': 'application/json',
        },
      );

      if (response.statusCode == 200) {
        return json.decode(response.body);
      } else {
        throw Exception(
          'Failed to fetch data. Status code: ${response.statusCode}, Body: ${response.body}',
        );
      }
    } catch (e) {
      print('Error fetching data: $e');
      rethrow;
    }
  }

  static Future<List<Species>> getSpecies({
    String? searchText,
    int? selectedOrganismGroup,
    int? selectedConservationStatus,
    int pageNumber = 1,
    int pageSize = 10,
    String? scientificName,
    String? commonName,
    int? kingdomId,
    int? phylumId,
    int? classId,
    int? orderId,
    int? familyId,
    int? genusId,
    int? organismGroupId,
    int? conservationStatusId,
    String? authorName,
    String? researchRecordNote,
    bool? isEndemic,
    bool? isNonEndemic,
  }) async {
    final data = await fetchFilteredData(
      searchText: searchText,
      selectedOrganismGroup: selectedOrganismGroup,
      selectedConservationStatus: selectedConservationStatus,
      pageNumber: pageNumber,
      pageSize: pageSize,
      scientificName: scientificName,
      commonName: commonName,
      kingdomId: kingdomId,
      phylumId: phylumId,
      classId: classId,
      orderId: orderId,
      familyId: familyId,
      genusId: genusId,
      organismGroupId: organismGroupId,
      conservationStatusId: conservationStatusId,
      authorName: authorName,
      researchRecordNote: researchRecordNote,
      isEndemic: isEndemic,
      isNonEndemic: isNonEndemic,
    );

    final speciesData = data['filteredSpecies'] != null && data['filteredSpecies']['\$values'] != null
        ? data['filteredSpecies']['\$values']
        : [];

    return (speciesData as List).map((item) {
      // ... (giữ nguyên logic chuyển đổi dữ liệu species như trong mã cũ)
      // Phần này giữ nguyên logic cũ của bạn để chuyển đổi dữ liệu species
      String groupName = 'Unknown';
      int recordCount = 0;

      // Trích xuất thông tin taxonomy
      String kingdomName = item['genus']?['family']?['order']?['class']?['phylum']?['kingdom']?['name'] ?? 'Unknown';
      String phylumName = item['genus']?['family']?['order']?['class']?['phylum']?['name'] ?? 'Unknown';
      String className = item['genus']?['family']?['order']?['class']?['name'] ?? 'Unknown';
      String orderName = item['genus']?['family']?['order']?['name'] ?? 'Unknown';
      String familyName = item['genus']?['family']?['name'] ?? 'Unknown';

      // Trích xuất thông tin conservation status
      String conservationStatusDescription = item['conservationStatus']?['description'] ?? 'No description available';
      String conservationStatusSeverity = item['conservationStatus']?['severity'] ?? 'Unknown';

      if (item['organismGroupSpecies'] != null &&
          item['organismGroupSpecies']['\$values'] != null &&
          item['organismGroupSpecies']['\$values'].isNotEmpty) {
        final groupData = item['organismGroupSpecies']['\$values'][0];
        groupName = groupData['organismGroup']['name'] ?? 'Unknown';
      }

      // Count research records
      if (item['researchRecordSpecies'] != null) {
        recordCount = item['researchRecordSpecies']['\$values'].length;
      }

      // Parse research records
      List<ResearchRecord> records = [];
      if (item['researchRecordSpecies'] != null &&
          item['researchRecordSpecies']['\$values'] != null) {
        records = (item['researchRecordSpecies']['\$values'] as List)
            .map((recordJson) => ResearchRecord.fromJson(recordJson['researchRecord'] ?? {}))
            .toList();
      }

      // Parse geographic distributions
      List<GeographicDistribution> distributions = [];
      if (item['geographicDistributions'] != null &&
          item['geographicDistributions']['\$values'] != null) {
        distributions = (item['geographicDistributions']['\$values'] as List)
            .map((distJson) => GeographicDistribution.fromJson(distJson))
            .toList();
      }

      // Create OrganismGroupSpecies
      final orgGroupSpecies = OrganismGroupSpecies(
        groupName: groupName,
        speciesCount: 0,
        recordCount: recordCount,
      );

      return Species(
        id: item['id'] ?? 0,
        scientificName: item['scientificName'] ?? 'Unknown',
        commonName: item['commonName'] ?? 'Unknown',
        genus: item['genus']?['name'] ?? 'Unknown',
        conservationStatus: item['conservationStatus']?['name'] ?? 'Unknown',
        conservationStatusId: item['conservationStatus']?['id'] ?? 0,
        imageUrl: item['imageUrl'] ?? '',
        taxonomyBrowser: '',
        isEndemic: item['isEndemic'] ?? false,
        organismGroupSpecies: orgGroupSpecies,
        genusId: item['genusId'] ?? 0,
        researchRecords: records,
        geographicDistributions: distributions,
        kingdomName: kingdomName,
        phylumName: phylumName,
        className: className,
        orderName: orderName,
        familyName: familyName,
        conservationStatusDescription: conservationStatusDescription,
        conservationStatusSeverity: conservationStatusSeverity,
      );
    }).toList();
  }

  static Future<Statistics> getStatistics({
    String? searchText,
    int? selectedOrganismGroup,
    int? selectedConservationStatus,
    int pageNumber = 1,
    int pageSize = 10,
    String? scientificName,
    String? commonName,
    int? kingdomId,
    int? phylumId,
    int? classId,
    int? orderId,
    int? familyId,
    int? genusId,
    int? organismGroupId,
    int? conservationStatusId,
    String? authorName,
    String? researchRecordNote,
    bool? isEndemic,
    bool? isNonEndemic,
  }) async {
    final data = await fetchFilteredData(
      searchText: searchText,
      selectedOrganismGroup: selectedOrganismGroup,
      selectedConservationStatus: selectedConservationStatus,
      pageNumber: pageNumber,
      pageSize: pageSize,
      scientificName: scientificName,
      commonName: commonName,
      kingdomId: kingdomId,
      phylumId: phylumId,
      classId: classId,
      orderId: orderId,
      familyId: familyId,
      genusId: genusId,
      organismGroupId: organismGroupId,
      conservationStatusId: conservationStatusId,
      authorName: authorName,
      researchRecordNote: researchRecordNote,
      isEndemic: isEndemic,
      isNonEndemic: isNonEndemic,
    );

    // Xử lý dữ liệu nhóm
    List<GroupStatistic> groupStats = [];
    if (data['statistics'] != null &&
        data['statistics']['groupStatistics'] != null &&
        data['statistics']['groupStatistics']['\$values'] != null) {
      groupStats = (data['statistics']['groupStatistics']['\$values'] as List)
          .map((group) => GroupStatistic(
        groupName: group['groupName'] ?? 'Unknown',
        speciesCount: group['speciesCount'] ?? 0,
      ))
          .toList();
    }

    return Statistics(
      totalSpecies: data['statistics']['totalSpecies'] ?? 0,
      totalRecords: data['statistics']['totalRecords'] ?? 0,
      groupStatistics: groupStats,
    );
  }
}