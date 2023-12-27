import 'dart:convert';
import 'dart:io';

import '../models/Post.dart';

class PostClient {
    final Map<String, dynamic> config;

    PostClient(this.config);


    // GetMain

    Future<List<Post>> GetMain(int page) async {
      var url = config["Post"]["GetMain"].replaceAll("{page}", page.toString()).toString();
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

    // GetMainMaxPage
    Future<int> GetMainMaxPage() async {
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
    Future<Post> Get(int id) async {
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
    Future<List<Post>> GetPostForUser(int userId, int page) async {
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
    Future<int> GetMaxPostForUser(int userId) async {
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
    Future<void> DeletePost(int id) async {
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
    Future<void> PostPost(Post post) async {
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
    Future<void> PutPost(Post post) async {
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

    Uri getUri(String url){
      return Uri(path: config["Path"] + "/" + url,
          scheme: config["Protocol"],
          host: config["Host"],
          port: int.parse(config["Port"]));
    }
}



void main(){
  var filePath = "lib/resources/appsettings.json";
  var content = File(filePath).readAsStringSync();
  var map = jsonDecode(content);
  PostClient c = PostClient(map["URL"]);
  c.GetMain(1);
}


