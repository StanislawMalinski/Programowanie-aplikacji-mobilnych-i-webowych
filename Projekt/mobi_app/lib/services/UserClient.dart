import 'dart:convert';
import 'dart:io';

import 'package:mobi_app/models/UserProfile.dart';

class UserClient {
  static Map<String, dynamic> config = {};

  //Get
  static Future<UserProfile> GetUser(int id) async {
    var url = config["UserProfile"]["Get"].replaceAll("{id}", id.toString()).toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var response = await client.getUrl(uri);
      var body = await response.close();
      var json = await body.transform(utf8.decoder).join();
      return UserProfile.fromJson(jsonDecode(json));
    } finally {
      client.close();
    }
  }

  static Future<void> DeleteUser(int id) async {
    var url = config["UserProfile"]["Delete"].replaceAll("{id}", id.toString()).toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var request = await client.deleteUrl(uri);
      var response = await request.close();
      if (response.statusCode != 200) {
        throw Exception('Failed to delete user.');
      }
    } finally {
      client.close();
    }
  }


  // Post
  static Future<void> PostUser(UserProfile user) async {
    var url = config["UserProfile"]["Post"].toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var request = await client.postUrl(uri);
      request.headers.contentType = ContentType("application", "json", charset: "utf-8");
      request.write(jsonEncode(user));
      var response = await request.close();
      if (response.statusCode != 200) {
        throw Exception('Failed to post user.');
      }
    } finally {
      client.close();
    }
  }

  // Put
  static Future<void> PutUser(UserProfile user) async {
    var url = config["UserProfile"]["Put"].toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var request = await client.putUrl(uri);
      request.headers.contentType = ContentType("application", "json", charset: "utf-8");
      request.write(jsonEncode(user));
      var response = await request.close();
      if (response.statusCode != 200) {
        throw Exception('Failed to put user.');
      }
    } finally {
      client.close();
    }
  }

  static Uri getUri(String url){
    return Uri(path: config["Path"] + "/" + url,
        scheme: config["Protocol"],
        host: config["Host"],
        port: int.parse(config["Port"]));
  }
}
