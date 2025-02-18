import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'api/api_service.dart';
import 'main_species_list_screen.dart';

class FilterAndSearchScreen extends StatefulWidget {
  @override
  _FilterAndSearchScreenState createState() => _FilterAndSearchScreenState();
}

class _FilterAndSearchScreenState extends State<FilterAndSearchScreen> {
  // Text controllers
  final TextEditingController _scientificNameController = TextEditingController();
  final TextEditingController _commonNameController = TextEditingController();
  final TextEditingController _authorNameController = TextEditingController();
  final TextEditingController _researchRecordNoteController = TextEditingController();
  final TextEditingController _organisGroupNameController = TextEditingController();
  final TextEditingController _kingdomController = TextEditingController();
  final TextEditingController _phylumController = TextEditingController();
  final TextEditingController _classController = TextEditingController();
  final TextEditingController _orderController = TextEditingController();
  final TextEditingController _familyController = TextEditingController();
  final TextEditingController _genusController = TextEditingController();
  final TextEditingController _organismGroupController = TextEditingController();
  final TextEditingController _conservationStatusController = TextEditingController();

  bool? _isEndemic;

  @override
  void initState() {
    super.initState();
  }

  // Helper method to create text input field
  TextFormField _buildTextField({
    TextEditingController? controller,
    required String hint,
    required TextInputType keyboardType,
  }) {
    return TextFormField(
      controller: controller,
      decoration: InputDecoration(
        hintText: hint,
        border: OutlineInputBorder(),
      ),
      keyboardType: keyboardType,
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Advanced Filter')),
      body: SingleChildScrollView(
        child: Padding(
          padding: EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: [
              // Text input fields
              _buildTextField(
                controller: _scientificNameController,
                hint: 'Enter Scientific Name',
                keyboardType: TextInputType.text,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _commonNameController,
                hint: 'Enter Common Name',
                keyboardType: TextInputType.text,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _kingdomController,
                hint: 'Enter Kingdom Name',
                keyboardType: TextInputType.text,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _phylumController,
                hint: 'Enter Phylum Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _classController,
                hint: 'Enter Class Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _orderController,
                hint: 'Enter Order Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _familyController,
                hint: 'Enter Family Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _genusController,
                hint: 'Enter Genus Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _organismGroupController,
                hint: 'Enter Organism Group Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),
              _buildTextField(
                controller: _conservationStatusController,
                hint: 'Enter Conservation Status Id',
                keyboardType: TextInputType.number,
              ),
              SizedBox(height: 8),

              // Endemic toggle remains the same
              SwitchListTile(
                title: Text('Is Endemic'),
                value: _isEndemic ?? false,
                onChanged: (bool value) {
                  setState(() {
                    _isEndemic = value;
                  });
                },
              ),

              // Apply Filters button
              ElevatedButton(
                onPressed: () {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => MainSpeciesListScreen(
                        scientificName: _scientificNameController.text.isNotEmpty
                            ? _scientificNameController.text
                            : null,
                        commonName: _commonNameController.text.isNotEmpty
                            ? _commonNameController.text
                            : null,
                        // Convert text inputs to integers, if not empty
                        kingdomId: _kingdomController.text.isNotEmpty
                            ? int.tryParse(_kingdomController.text)
                            : null,
                        phylumId: _phylumController.text.isNotEmpty
                            ? int.tryParse(_phylumController.text)
                            : null,
                        classId: _classController.text.isNotEmpty
                            ? int.tryParse(_classController.text)
                            : null,
                        orderId: _orderController.text.isNotEmpty
                            ? int.tryParse(_orderController.text)
                            : null,
                        familyId: _familyController.text.isNotEmpty
                            ? int.tryParse(_familyController.text)
                            : null,
                        genusId: _genusController.text.isNotEmpty
                            ? int.tryParse(_genusController.text)
                            : null,
                        organismGroupId: _organismGroupController.text.isNotEmpty
                            ? int.tryParse(_organismGroupController.text)
                            : null,
                        conservationStatusId: _conservationStatusController.text.isNotEmpty
                            ? int.tryParse(_conservationStatusController.text)
                            : null,
                        authorName: _authorNameController.text.isNotEmpty
                            ? _authorNameController.text
                            : null,
                        researchRecordNote: _researchRecordNoteController.text.isNotEmpty
                            ? _researchRecordNoteController.text
                            : null,
                        isEndemic: _isEndemic,
                      ),
                    ),
                  );
                },
                child: Text('Apply Filters'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
