import 'dart:convert';
import 'dart:io';

import 'package:mobi_app/services/UserClient.dart';
import 'package:mobi_app/services/PostClient.dart';
import 'package:mobi_app/services/CommentClient.dart';

class Configuration{
  static const String configContent = '''{
      "Logging": {
  "LogLevel": {
  "Default": "Information",
  "Microsoft.AspNetCore": "Warning"
  }
  },
  "PathToDictionary": "language.json",
  "AllowedHosts": "*",
  "URL": {
  "Protocol": "https",
  "Port": "7061",
  "Host": "localhost",
  "Path": "forum",
  "BaseURL": "https://localhost:7061/forum/",
  "Comment": {
  "Get": "Comment/{id}",
  "GetCommentForPost": "Post/{id}/Comment",
  "Delete": "Comment/{id}",
  "Post": "Comment",
  "Put": "Comment"
  },
  "Post": {
  "GetMain": "Post/page={page}",
  "GetMainMaxPage": "Post/maxpage",
  "Get": "Post/{id}",
  "GetPostForUser": "Post/{id}/page={page}",
  "GetMaxPostForUser": "Post/{id}/maxpage",
  "Delete": "Post/{id}",
  "Post": "Post",
  "Put": "Post"
  },
  "UserProfile": {
  "Get": "UserProfile/{id}",
  "Delete": "UserProfile/{id}",
  "Post": "UserProfile",
  "Put": "UserProfile"
  }
  }
} ''';

  static void load(){
    var content = Configuration.configContent;
    var map = jsonDecode(content);

    print("Załadowno konfigurację");

    UserClient.config = map["URL"];
    PostClient.config = map["URL"];
    CommentClient.config = map["URL"];
  }


}