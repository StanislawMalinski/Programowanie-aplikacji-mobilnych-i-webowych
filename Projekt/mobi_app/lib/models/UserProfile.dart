// -- user_profile.dart --
import 'package:json_annotation/json_annotation.dart';

part 'UserProfile.g.dart';

@JsonSerializable()
class UserProfile {
  int id;
  String userName;
  String email;
  String bio;

  UserProfile(this.id,this.userName,this.email,this.bio,);

  factory UserProfile.fromJson(Map<String, dynamic> json) => _$UserProfileFromJson(json);

  Map<String, dynamic> toJson() => _$UserProfileToJson(this);
}