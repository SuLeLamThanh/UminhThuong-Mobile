import 'package:flutter/material.dart';
import 'api/api_service.dart';
import 'models/species.dart';
import 'species_detail_screen.dart';
import 'filter_and_search_screen.dart';
import 'statistics_screen.dart';

class MainSpeciesListScreen extends StatefulWidget {
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

  MainSpeciesListScreen({
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
  _MainSpeciesListScreenState createState() => _MainSpeciesListScreenState();
}

class _MainSpeciesListScreenState extends State<MainSpeciesListScreen> {
  late Future<List<Species>> _speciesFuture;

  @override
  void initState() {
    super.initState();
    _loadSpecies();
  }

  @override
  void didUpdateWidget(MainSpeciesListScreen oldWidget) {
    super.didUpdateWidget(oldWidget);
    // Check if any filter parameters have changed
    if (_filterParametersChanged(oldWidget)) {
      _loadSpecies();
    }
  }

  bool _filterParametersChanged(MainSpeciesListScreen oldWidget) {
    return
      widget.scientificName != oldWidget.scientificName ||
          widget.commonName != oldWidget.commonName ||
          widget.kingdomId != oldWidget.kingdomId ||
          widget.phylumId != oldWidget.phylumId ||
          widget.classId != oldWidget.classId ||
          widget.orderId != oldWidget.orderId ||
          widget.familyId != oldWidget.familyId ||
          widget.genusId != oldWidget.genusId ||
          widget.organismGroupId != oldWidget.organismGroupId ||
          widget.conservationStatusId != oldWidget.conservationStatusId ||
          widget.authorName != oldWidget.authorName ||
          widget.researchRecordNote != oldWidget.researchRecordNote ||
          widget.isEndemic != oldWidget.isEndemic;
  }

  void _loadSpecies() {
    setState(() {
      _speciesFuture = ApiService.getSpecies(
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
        title: Text('Main Species List'),
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            DrawerHeader(
              decoration: BoxDecoration(
                color: Colors.blue,
              ),
              child: Text(
                'Navigation',
                style: TextStyle(
                  color: Colors.white,
                  fontSize: 24,
                ),
              ),
            ),
            ListTile(
              leading: Icon(Icons.search),
              title: Text('Filter and Search'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => FilterAndSearchScreen(),
                  ),
                );
              },
            ),
            ListTile(
              leading: Icon(Icons.analytics),
              title: Text('Statistics'),
              onTap: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => StatisticsScreen(
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
                    ),
                  ),
                );
              },
            ),
          ],
        ),
      ),
      body: FutureBuilder<List<Species>>(
        future: _speciesFuture,
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return GridView.builder(
              gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 2,
                childAspectRatio: 0.8,
              ),
              itemCount: snapshot.data!.length,
              itemBuilder: (context, index) {
                final species = snapshot.data![index];
                return GestureDetector(
                  onTap: () {
                    Navigator.push(
                      context,
                      MaterialPageRoute(
                        builder: (context) => SpeciesDetailScreen(species: species),
                      ),
                    );
                  },
                  child: Card(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Expanded(
                          child: Image.network(
                            species.imageUrl,
                            fit: BoxFit.cover,
                          ),
                        ),
                        SizedBox(height: 8),
                        Padding(
                          padding: EdgeInsets.all(8),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(
                                species.commonName,
                                style: TextStyle(fontWeight: FontWeight.bold),
                              ),
                              Text(species.scientificName),
                              Text('Organism Group: ${species.organismGroupSpecies.groupName}'),
                              Text('Research Records: ${species.organismGroupSpecies.recordCount}'),
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                );
              },
            );
          } else if (snapshot.hasError) {
            return Center(
              child: Text('Error fetching species data'),
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