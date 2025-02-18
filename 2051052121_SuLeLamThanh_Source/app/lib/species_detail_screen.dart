import 'package:flutter/material.dart';
import 'models/species.dart';

class SpeciesDetailScreen extends StatelessWidget {
  final Species species;

  SpeciesDetailScreen({required this.species});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(species.commonName),
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(16),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            // Image Section
            Image.network(
              species.imageUrl,
              fit: BoxFit.cover,
              width: double.infinity,
              height: 200,
            ),
            SizedBox(height: 16),

            // Basic Species Information
            Text(
              'Scientific Name: ${species.scientificName}',
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 8),

            // Conservation Status Details
            Text(
              'Conservation Status: ${species.conservationStatus}',
              style: TextStyle(fontWeight: FontWeight.bold),
            ),
            Text('Status Description: ${species.conservationStatusDescription}'),
            Text('Severity: ${species.conservationStatusSeverity}'),
            SizedBox(height: 8),

            // Taxonomy Information
            Text(
              'Taxonomy Hierarchy',
              style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            ),
            Text('Kingdom: ${species.kingdomName}'),
            Text('Phylum: ${species.phylumName}'),
            Text('Class: ${species.className}'),
            Text('Order: ${species.orderName}'),
            Text('Family: ${species.familyName}'),
            Text('Genus: ${species.genus}'),
            SizedBox(height: 8),

            // Organism Group
            Text('Organism Group: ${species.organismGroupName}'),
            SizedBox(height: 8),

            // Research Records
            Text(
              'Research Records:',
              style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            ),
            if (species.researchRecords.isNotEmpty)
              ...species.researchRecords.map((record) => Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(' - ${record.name}'),
                  Text('   Description: ${record.description}'),
                  Text('   Result: ${record.result}'),
                ],
              )),
            if (species.researchRecords.isEmpty)
              Text('No research records available'),
            SizedBox(height: 8),

            // Endemic Status
            Text('Endemic: ${species.isEndemic ? "Yes" : "No"}'),
            SizedBox(height: 8),

            // Geographic Distributions
            Text(
              'Geographic Distributions:',
              style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
            ),
            if (species.geographicDistributions.isNotEmpty)
              ...species.geographicDistributions.map((dist) => Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(' - Region: ${dist.region}'),
                  Text('   Country: ${dist.country}'),
                  Text('   Location: ${dist.location}'),
                  Text('   Notes: ${dist.notes}'),
                ],
              )),
            if (species.geographicDistributions.isEmpty)
              Text('No geographic distribution data available'),
          ],
        ),
      ),
    );
  }
}