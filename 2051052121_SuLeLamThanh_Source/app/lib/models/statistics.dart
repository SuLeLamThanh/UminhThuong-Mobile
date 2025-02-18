// lib/models/statistics.dart
class Statistics {
  final int totalSpecies;
  final int totalRecords;
  final List<GroupStatistic> groupStatistics;

  Statistics({
    required this.totalSpecies,
    required this.totalRecords,
    required this.groupStatistics,
  });
}

class GroupStatistic {
  final String groupName;
  final int speciesCount;

  GroupStatistic({
    required this.groupName,
    required this.speciesCount,
  });
}