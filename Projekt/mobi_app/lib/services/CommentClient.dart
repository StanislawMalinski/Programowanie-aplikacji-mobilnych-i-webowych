import 'dart:convert';
import 'dart:io';

import 'package:mobi_app/models/Comment.dart';

class CommentClient {
  static Map<String, dynamic> config = {};

//    "Comment": {
//       "Get": "Comment/{id}",


  //GetComment
  static Future<Comment> GetComment(int id) async {
    var url = config["Comment"]["Get"].replaceAll("{id}", id.toString()).toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var response = await client.getUrl(uri);
      var body = await response.close();
      var json = await body.transform(utf8.decoder).join();
      return Comment.fromJson(jsonDecode(json));
    } finally {
      client.close();
    }
  }

//       "GetCommentForPost": "Post/{id}/Comment",
  static Future<List<Comment>> GetCommentsForPost(int id) async {
    var url = config["Comment"]["GetCommentForPost"].replaceAll("{id}", id.toString()).toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var response = await client.getUrl(uri);
      var body = await response.close();
      var json = await body.transform(utf8.decoder).join();
      var list_resp = jsonDecode(json) as List<dynamic>;
      return list_resp.map((e) => Comment.fromJson(e)).toList();
    } finally {
      client.close();
    }
  }

//       "Delete": "Comment/{id}",
  static Future<void> DeleteComment(int id) async {
    var url = config["Comment"]["Delete"].replaceAll("{id}", id.toString()).toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var request = await client.deleteUrl(uri);
      var response = await request.close();
      if (response.statusCode != 200) {
        throw Exception('Failed to delete comment.');
      }
    } finally {
      client.close();
    }
  }

//       "Post": "Comment",
  static Future<void> PostComment(Comment comment) async {
    var url = config["Comment"]["Post"].toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var request = await client.postUrl(uri);
      request.headers.contentType = ContentType("application", "json", charset: "utf-8");
      request.write(jsonEncode(comment));
      var response = await request.close();
      if (response.statusCode != 200) {
        throw Exception('Failed to post comment.');
      }
    } finally {
      client.close();
    }
  }

//       "Put": "Comment"
  static Future<void> PutComment(Comment comment) async {
    var url = config["Comment"]["Put"].toString();
    var uri = getUri(url);
    var client = HttpClient();
    try
    {
      var request = await client.putUrl(uri);
      request.headers.contentType = ContentType("application", "json", charset: "utf-8");
      request.write(jsonEncode(comment));
      var response = await request.close();
      if (response.statusCode != 200) {
        throw Exception('Failed to put comment.');
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
