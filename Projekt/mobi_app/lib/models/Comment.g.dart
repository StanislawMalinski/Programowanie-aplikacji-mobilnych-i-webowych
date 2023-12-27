// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'Comment.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Comment _$CommentFromJson(Map<String, dynamic> json) => Comment(
      json['id'] as int,
      json['text'] as String,
      DateTime.parse(json['createdAt'] as String),
      json['user'] == null ? null : UserProfile.fromJson(json['user'] as Map<String, dynamic>),
      json['postId'] as int,
    );

Map<String, dynamic> _$CommentToJson(Comment instance) => <String, dynamic>{
      'id': instance.id,
      'text': instance.text,
      'createdAt': instance.createdAt.toIso8601String(),
      'user': instance.user,
      'postId': instance.postId,
    };
