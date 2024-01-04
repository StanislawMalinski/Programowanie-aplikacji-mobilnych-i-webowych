import 'package:mobi_app/models/UserProfile.dart';

class CurrentUser{
  static UserProfile userProfile = UserProfile(-1, "", "", "");
  static String token = "";

  static UserProfile getUserProfile(){
    return userProfile;
  }

  static void setUserProfile(UserProfile userProfile){
    CurrentUser.userProfile = userProfile;
  }

  static String getToken(){
    return token;
  }

  static void setToken(String token){
    CurrentUser.token = token;
  }

  static int getId() {
    return userProfile.id;
  }
}