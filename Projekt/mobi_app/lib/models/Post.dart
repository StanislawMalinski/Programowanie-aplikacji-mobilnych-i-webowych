import 'package:json_annotation/json_annotation.dart';
import 'Comment.dart';
import 'UserProfile.dart';

part 'Post.g.dart';

@JsonSerializable()
class Post {
  int id;
  String title;
  String content;
  DateTime createdAt;
  UserProfile user;
  List<Comment> comments;

  Post(this.id,this.title,this.content,this.createdAt,this.user,this.comments,);

  factory Post.fromJson(Map<String, dynamic> json) => _$PostFromJson(json);

  Map<String, dynamic> toJson() => _$PostToJson(this);
}
