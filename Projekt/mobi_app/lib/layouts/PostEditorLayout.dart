

import 'package:flutter/material.dart';
import 'package:mobi_app/services/CurrentUser.dart';

import '../models/Post.dart';
import 'components/BottomNavigationBarComponent.dart';

class PostEditorBodyLayout extends StatefulWidget {
  @override
  _PostEditorBodyLayoutState createState() => _PostEditorBodyLayoutState();
}

class _PostEditorBodyLayoutState extends State<PostEditorBodyLayout> {
  var post;
  final titleController = TextEditingController();

  final contentController = TextEditingController();

  @override
  void dispose() {
    // Clean up the controller when the widget is disposed.
    titleController.dispose();
    contentController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(title: const Text("Post Editor")),
      bottomNavigationBar: const BottomNavigationComponent(),
        body: Container(
        child: Column(

          children: [
             Container(
              margin: const EdgeInsets.all(8),
              child: TextField(
                controller: titleController,
                minLines: 1,
                maxLines: 2,
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Title',
                ),
              ),
            ),
            Container(
              margin: const EdgeInsets.all(8),
              child: TextField(
                controller: contentController,
                minLines: 1,
                maxLines: 4,
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Content',
                ),
              ),
            ),
            Container(
              margin: const EdgeInsets.all(8),
              child: ElevatedButton(
                onPressed: () {
                  post = Post(0, titleController.text, contentController.text, DateTime.now(), CurrentUser.getUserProfile(), []);
                  submitPost();
                },
                child: const Text('Submit'),
              ),
            ),
          ],
        ),
      )
    );
  }

  void loadInPost(){
  // TODO
  }

  void submitPost() {
    // TODO
    print(post);
  }
}
