// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'UserProfile.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

UserProfile _$UserProfileFromJson(Map<String, dynamic> json) => UserProfile(
      json['id'] as int,
      json['userName'] as String,
      json['email'] as String,
      json['bio'] as String,
    );

Map<String, dynamic> _$UserProfileToJson(UserProfile instance) =>
    <String, dynamic>{
      'id': instance.id,
      'userName': instance.userName,
      'email': instance.email,
      'bio': instance.bio,
    };
