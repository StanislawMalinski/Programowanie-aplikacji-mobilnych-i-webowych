import 'dart:convert';
import 'dart:io';

class PostClient {
    final HttpClient _httpClient = HttpClient();
    final Map<String, dynamic> config;
    final String configFilePath;

  PostClient(this.config, this.configFilePath);
}


