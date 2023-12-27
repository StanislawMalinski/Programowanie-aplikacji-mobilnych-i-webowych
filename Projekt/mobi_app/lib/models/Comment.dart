import 'package:json_annotation/json_annotation.dart';
import 'UserProfile.dart';

part 'Comment.g.dart';

@JsonSerializable()
class Comment {
  int id;
  String text;
  DateTime createdAt;
  UserProfile? user;
  int postId;

  Comment(this.id, this.text, this.createdAt, this.user, this.postId,);

  factory Comment.fromJson(Map<String, dynamic> json) =>
      _$CommentFromJson(json);

  Map<String, dynamic> toJson() => _$CommentToJson(this);
}