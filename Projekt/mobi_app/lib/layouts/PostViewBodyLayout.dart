import 'package:flutter/material.dart';
import 'package:mobi_app/models/Post.dart';

class PostViewBodyLayout extends StatefulWidget{
  final post;
  const PostViewBodyLayout(this.post, {super.key});
  @override
  State<StatefulWidget> createState() => _PostViewBodyLayoutState(post);
}

class _PostViewBodyLayoutState extends State<PostViewBodyLayout>{
  final post;
  _PostViewBodyLayoutState(this.post);

  @override
  Widget build(BuildContext context) {
    return Container();
  }
}