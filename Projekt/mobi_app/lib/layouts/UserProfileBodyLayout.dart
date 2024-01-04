import 'package:flutter/material.dart';
import 'package:mobi_app/layouts/components/BodyLayout.dart';
import 'package:mobi_app/models/Post.dart';
import 'package:mobi_app/models/UserProfile.dart';

import 'PostLayout.dart';
import 'components/BodyLayout.dart';

class MyProfileBodyLayout extends BodyLayout<Post> {
  @override
  _MyProfileBodyLayoutState createState() => _MyProfileBodyLayoutState();
}

class _MyProfileBodyLayoutState extends BodyLayoutState<Post> {
  @override
  Future<List<Post>> loadElements(int page) async {
    setTitle("Profile");
    return [Post(1, "title1", "body", DateTime.now(), UserProfile(1, "name", "email", "bio"), []),
            Post(2, "title2", "body", DateTime.now(), UserProfile(2, "name", "email", "bio"), []),
            Post(3, "title3", "body", DateTime.now(), UserProfile(3, "name", "email", "bio"), []),
            Post(4, "title4", "body", DateTime.now(), UserProfile(4, "name", "email", "bio"), []),
            Post(5, "title5", "body", DateTime.now(), UserProfile(5, "name", "email", "bio"), []),
            Post(6, "title6", "body", DateTime.now(), UserProfile(6, "name", "email", "bio"), []),
            Post(7, "title7", "body", DateTime.now(), UserProfile(7, "name", "email", "bio"), []),
            Post(8, "title8", "body", DateTime.now(), UserProfile(8, "name", "email", "bio"), []),
            Post(9, "title9", "body", DateTime.now(), UserProfile(9, "name", "email", "bio"), []),
            Post(10, "title10", "body", DateTime.now(), UserProfile(10, "name", "email", "bio"), []),];
    //return PostClient.get(page);
  }

  @override
  Widget getWidget(Post element) {
    return PostLayout.getPost(element);
  }

  @override
   getMaxPage() {
    return 3; // TODO replace with dynamic value
  }
}
