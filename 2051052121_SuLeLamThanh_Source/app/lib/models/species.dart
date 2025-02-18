import 'package:logger/logger.dart';

class Species {
  final int id;
  final String scientificName;
  final String commonName;
  final String genus;
  final String conservationStatus;
  final int conservationStatusId;
  final String imageUrl;
  final String taxonomyBrowser;
  final bool isEndemic;
  final OrganismGroupSpecies organismGroupSpecies;
  final int genusId;
  final List<ResearchRecord> researchRecords; // Added researchRecords property
  // New taxonomy fields
  final String kingdomName;
  final String phylumName;
  final String className;
  final String orderName;
  final String familyName;

  // New conservation status fields
  final String conservationStatusDescription;
  final String conservationStatusSeverity;
  // Adding new getters to match the API service requirements
  String get organismGroupName => organismGroupSpecies.groupName;

  // Maintain the logger
  static final Logger logger = Logger();

  // New fields for geographic distributions
  final List<GeographicDistribution> geographicDistributions; // Added field

  Species({
    required this.id,
    required this.scientificName,
    required this.commonName,
    required this.genus,
    required this.conservationStatus,
    required this.conservationStatusId,
    required this.imageUrl,
    required this.taxonomyBrowser,
    required this.isEndemic,
    required this.organismGroupSpecies,
    required this.genusId,
    required this.researchRecords, // Include this in constructor
    required this.geographicDistributions, // Include this in constructor
    // New required parameters
    required this.kingdomName,
    required this.phylumName,
    required this.className,
    required this.orderName,
    required this.familyName,
    required this.conservationStatusDescription,
    required this.conservationStatusSeverity,
  });

  factory Species.fromJson(Map<String, dynamic> json) {
    try {
      logger.d('Parsing Species JSON: $json');

      // Extract taxonomy details
      String kingdomName = json['genus']?['family']?['order']?['class']?['phylum']?['kingdom']?['name'] ?? 'Unknown';
      String phylumName = json['genus']?['family']?['order']?['class']?['phylum']?['name'] ?? 'Unknown';
      String className = json['genus']?['family']?['order']?['class']?['name'] ?? 'Unknown';
      String orderName = json['genus']?['family']?['order']?['name'] ?? 'Unknown';
      String familyName = json['genus']?['family']?['name'] ?? 'Unknown';

      // Extract organism group name from nested structure
      String groupName = 'Unknown';
      if (json['organismGroupSpecies'] != null &&
          json['organismGroupSpecies']['\$values'] != null &&
          json['organismGroupSpecies']['\$values'].isNotEmpty) {
        final groupData = json['organismGroupSpecies']['\$values'][0];
        groupName = groupData['organismGroup']['name'] ?? 'Unknown';
      }

      // Parse research records
      List<ResearchRecord> records = [];
      if (json['researchRecordSpecies'] != null &&
          json['researchRecordSpecies']['\$values'] != null) {
        records = (json['researchRecordSpecies']['\$values'] as List)
            .map((recordJson) => ResearchRecord.fromJson(recordJson['researchRecord'] ?? {}))
            .toList();
      }

      // Parse geographic distributions
      List<GeographicDistribution> distributions = [];
      if (json['geographicDistributions'] != null &&
          json['geographicDistributions']['\$values'] != null) {
        distributions = (json['geographicDistributions']['\$values'] as List)
            .map((distJson) => GeographicDistribution.fromJson(distJson))
            .toList();
      }

      // Conservation status details
      String conservationStatusName = json['conservationStatus']?['name'] ?? 'Unknown';
      String conservationStatusDescription = json['conservationStatus']?['description'] ?? 'No description available';
      String conservationStatusSeverity = json['conservationStatus']?['severity'] ?? 'Unknown';

      if (json['organismGroupSpecies'] != null &&
          json['organismGroupSpecies']['\$values'] != null &&
          json['organismGroupSpecies']['\$values'].isNotEmpty) {
        final groupData = json['organismGroupSpecies']['\$values'][0];
        groupName = groupData['organismGroup']['name'] ?? 'Unknown';
      }

      // Parse research records
      // List<ResearchRecord> records = [];
      // if (json['researchRecordSpecies'] != null &&
      //     json['researchRecordSpecies']['\$values'] != null) {
      //   records = (json['researchRecordSpecies']['\$values'] as List)
      //       .map((recordJson) => ResearchRecord.fromJson(recordJson))
      //       .toList();
      // }

      // Parse geographic distributions
      // List<GeographicDistribution> distributions = [];
      // if (json['geographicDistributions'] != null &&
      //     json['geographicDistributions']['\$values'] != null) {
      //   distributions = (json['geographicDistributions']['\$values'] as List)
      //       .map((distJson) => GeographicDistribution.fromJson(distJson))
      //       .toList();
      // }

      return Species(
        id: json['id'] ?? 0,
        scientificName: json['scientificName'] ?? 'Unknown',
        commonName: json['commonName'] ?? 'Unknown',
        genus: json['genus']?['name'] ?? 'Unknown',
        conservationStatus: json['conservationStatus']?['name'] ?? 'Unknown',
        conservationStatusId: json['conservationStatus']?['id'] ?? 0,
        imageUrl: json['imageUrl'] ?? '',
        taxonomyBrowser: json['taxonomyBrowser'] ?? '',
        isEndemic: json['isEndemic'] ?? false,
        organismGroupSpecies: OrganismGroupSpecies.fromJson(
            json['organismGroupSpecies']?['\$values']?.first ?? {}),
        genusId: json['genusId'] ?? 0,
        researchRecords: records, // Assign parsed research records
        geographicDistributions: distributions, // Assign parsed geographic distributions
        // Add new taxonomy fields
        kingdomName: kingdomName,
        phylumName: phylumName,
        className: className,
        orderName: orderName,
        familyName: familyName,

        // Add conservation status details
        conservationStatusDescription: conservationStatusDescription,
        conservationStatusSeverity: conservationStatusSeverity,
      );
    } catch (e) {
      logger.e('Error parsing Species JSON: $e');
      logger.e('Problematic JSON: $json');
      throw Exception('Failed to parse Species: $e');
    }
  }
}

class OrganismGroupSpecies {
  final String groupName;
  final int speciesCount;
  final int recordCount;

  OrganismGroupSpecies({
    required this.groupName,
    required this.speciesCount,
    required this.recordCount,
  });

  factory OrganismGroupSpecies.fromJson(Map<String, dynamic> json) {
    return OrganismGroupSpecies(
      groupName: json['groupName'] ?? 'Unknown',
      speciesCount: json['speciesCount'] ?? 0,
      recordCount: json['recordCount'] ?? 0,
    );
  }
}

class ResearchRecord {
  final String name;
  final String description;
  final String result;

  ResearchRecord({
    required this.name,
    required this.description,
    required this.result,
  });

  factory ResearchRecord.fromJson(Map<String, dynamic> json) {
    return ResearchRecord(
      name: json['name'] ?? 'Unknown',
      description: json['description'] ?? 'No description provided',
      result: json['result'] ?? 'Unknown',
    );
  }
}

class GeographicDistribution {
  final String region;
  final String country;
  final String location;
  final String notes;

  GeographicDistribution({
    required this.region,
    required this.country,
    required this.location,
    required this.notes,
  });

  factory GeographicDistribution.fromJson(Map<String, dynamic> json) {
    return GeographicDistribution(
      region: json['region'] ?? 'Unknown',
      country: json['country'] ?? 'Unknown',
      location: json['location'] ?? 'Unknown',
      notes: json['notes'] ?? 'No notes provided',
    );
  }
}
