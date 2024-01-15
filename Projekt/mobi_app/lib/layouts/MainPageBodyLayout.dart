import 'package:flutter/material.dart';
import 'package:mobi_app/layouts/components/BodyLayout.dart';
import 'package:mobi_app/services/PostClient.dart';

import '../models/Post.dart';
import '../models/UserProfile.dart';
import 'PostLayout.dart';

class MainPageBodyLayout extends BodyLayout<Post>{
  @override
  _MainPageBodyLayoutState createState() => _MainPageBodyLayoutState();
}

class _MainPageBodyLayoutState extends BodyLayoutState<Post> {
  @override
  Future<List<Post>> loadElements(int page) async {
    return loadPosts(page);
  }

  @override
  Widget getWidget(Post element) {
    return PostLayout.getPost(element);
  }

  @override
  int getMaxPage(){
    return 3; // TODO replace with dynamic value
  }

  Future<List<Post>> loadPosts(int page) async {
    var list = await PostClient.getMain(page);
    list.add(Post(1, "title1", "body", DateTime.now(), UserProfile(1, "name", "email", "bio"), []));
    // return list;
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
  }
}