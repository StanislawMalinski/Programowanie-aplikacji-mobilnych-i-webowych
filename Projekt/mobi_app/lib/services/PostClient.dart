import 'dart:convert';
import 'dart:io';

import '../models/Post.dart';

class PostClient {
    static Map<String, dynamic> config = {};

    // GetMain
    static Future<List<Post>> getMain(int page) async {
      var url = config["Post"]["GetMain"].replaceAll("{page}", page.toString()).toString();
      var uri = getUri(url);
      print(uri);
      var client = HttpClient();
      try
      {
        var response = await client.getUrl(uri);
        var body = await response.close();
        var json = await body.transform(utf8.decoder).join();
        var list_resp = jsonDecode(json) as List<dynamic>;
        return list_resp.map((e) => Post.fromJson(e)).toList();
      } finally {
        client.close();
      }
    }

    // GetMainMaxPage
    static Future<int> getMainMaxPage() async {
      var url = config["Post"]["GetMainMaxPage"].toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var response = await client.getUrl(uri);
        var body = await response.close();
        var json = await body.transform(utf8.decoder).join();
        return int.parse(json);
      } finally {
        client.close();
      }
    }

    // Get
    static Future<Post> get(int id) async {
      var url = config["Post"]["Get"].replaceAll("{id}", id.toString()).toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var response = await client.getUrl(uri);
        var body = await response.close();
        var json = await body.transform(utf8.decoder).join();
        return Post.fromJson(jsonDecode(json));
      } finally {
        client.close();
      }
    }

    // GetPostForUser
    static Future<List<Post>> getPostForUser(int userId, int page) async {
      var url = config["Post"]["GetPostForUser"]
          .replaceAll("{id}", userId.toString())
          .replaceAll("{page}", page.toString())
          .toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var response = await client.getUrl(uri);
        var body = await response.close();
        var json = await body.transform(utf8.decoder).join();
        var list_resp = jsonDecode(json) as List<dynamic>;
        return list_resp.map((e) => Post.fromJson(e)).toList();
      } finally {
        client.close();
      }
    }

    // GetMaxPostForUser
    static Future<int> getMaxPostForUser(int userId) async {
      var url = config["Post"]["GetMaxPostForUser"]
          .replaceAll("{id}", userId.toString())
          .toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var response = await client.getUrl(uri);
        var body = await response.close();
        var json = await body.transform(utf8.decoder).join();
        return int.parse(json);
      } finally {
        client.close();
      }
    }

    // Delete
    static Future<void> deletePost(int id) async {
      var url = config["Post"]["Delete"].replaceAll("{id}", id.toString()).toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var request = await client.deleteUrl(uri);
        await request.close();
      } finally {
        client.close();
      }
    }

    // Post
    static Future<void> postPost(Post post) async {
      var url = config["Post"]["Post"].toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var request = await client.postUrl(uri);
        request.headers.contentType = ContentType("application", "json", charset: "utf-8");
        request.write(jsonEncode(post));
        await request.close();
      } finally {
        client.close();
      }
    }

    // Put
    static Future<void> putPost(Post post) async {
      var url = config["Post"]["Put"].toString();
      var uri = getUri(url);
      var client = HttpClient();
      try
      {
        var request = await client.putUrl(uri);
        request.headers.contentType = ContentType("application", "json", charset: "utf-8");
        request.write(jsonEncode(post));
        await request.close();
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



void main() async{
  var filePath = "resources/config.json";
  var content = File(filePath).readAsStringSync();
  var map = jsonDecode(content);

  PostClient.config = map["URL"];

  await PostClient.getMain(1).then((value) => print(value));
}


