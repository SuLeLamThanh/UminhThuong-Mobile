import 'package:flutter/material.dart';
import 'package:fl_chart/fl_chart.dart';
import 'api/api_service.dart';
import 'models/statistics.dart';

class StatisticsScreen extends StatefulWidget {
  // Extended filter parameters
  final String? scientificName;
  final String? commonName;
  final int? kingdomId;
  final int? phylumId;
  final int? classId;
  final int? orderId;
  final int? familyId;
  final int? genusId;
  final int? organismGroupId;
  final int? conservationStatusId;
  final String? authorName;
  final String? researchRecordNote;
  final bool? isEndemic;

  StatisticsScreen({
    this.scientificName,
    this.commonName,
    this.kingdomId,
    this.phylumId,
    this.classId,
    this.orderId,
    this.familyId,
    this.genusId,
    this.organismGroupId,
    this.conservationStatusId,
    this.authorName,
    this.researchRecordNote,
    this.isEndemic,
  });

  @override
  _StatisticsScreenState createState() => _StatisticsScreenState();
}

class _StatisticsScreenState extends State<StatisticsScreen> {
  late Future<Statistics> _statisticsFuture;

  @override
  void initState() {
    super.initState();
    _loadStatistics();
  }

  void _loadStatistics() {
    setState(() {
      _statisticsFuture = ApiService.getStatistics(
        scientificName: widget.scientificName,
        commonName: widget.commonName,
        kingdomId: widget.kingdomId,
        phylumId: widget.phylumId,
        classId: widget.classId,
        orderId: widget.orderId,
        familyId: widget.familyId,
        genusId: widget.genusId,
        organismGroupId: widget.organismGroupId,
        conservationStatusId: widget.conservationStatusId,
        authorName: widget.authorName,
        researchRecordNote: widget.researchRecordNote,
        isEndemic: widget.isEndemic,
      );
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Statistics'),
      ),
      body: FutureBuilder<Statistics>(
        future: _statisticsFuture,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            final statistics = snapshot.data!;
            return Column(
              children: [
                Expanded(
                  child: PieChartWidget(
                    data: statistics.groupStatistics,
                  ),
                ),
                Padding(
                  padding: EdgeInsets.all(16),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        'Total Species: ${statistics.totalSpecies}',
                        style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                      ),
                      SizedBox(height: 8),
                      Text(
                        'Total Research Records: ${statistics.totalRecords}',
                        style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                      ),
                    ],
                  ),
                ),
              ],
            );
          } else if (snapshot.hasError) {
            return Center(
              child: Text('Error fetching statistics data'),
            );
          } else {
            return Center(
              child: CircularProgressIndicator(),
            );
          }
        },
      ),
    );
  }
}

class PieChartWidget extends StatelessWidget {
  final List<GroupStatistic> data;

  PieChartWidget({required this.data});

  @override
  Widget build(BuildContext context) {
    final sections = data.map((stat) {
      return PieChartSectionData(
        value: stat.speciesCount.toDouble(),
        title: stat.groupName,
        color: _getColorForIndex(data.indexOf(stat)),
        radius: 50,
        titleStyle: TextStyle(fontSize: 12, fontWeight: FontWeight.bold),
      );
    }).toList();

    return PieChart(
      PieChartData(
        sections: sections,
        centerSpaceRadius: 40,
        sectionsSpace: 2,
        borderData: FlBorderData(show: false),
      ),
    );
  }

  Color _getColorForIndex(int index) {
    const colors = [
      Colors.red,
      Colors.green,
      Colors.blue,
      Colors.yellow,
      Colors.orange,
      Colors.purple,
      Colors.cyan,
    ];
    return colors[index % colors.length];
  }
}