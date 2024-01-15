import 'package:flutter/material.dart';

import 'package:mobi_app/layouts/UserProfileBodyLayout.dart';
import 'package:mobi_app/layouts/PostEditorLayout.dart';
import 'package:mobi_app/models/UserProfile.dart';

import 'package:mobi_app/services/Configuration.dart';
import 'package:mobi_app/services/CurrentUser.dart';

import 'layouts/MainPageBodyLayout.dart';
import 'layouts/PostViewBodyLayout.dart';
import 'layouts/components/BottomNavigationBarComponent.dart';
import 'models/Post.dart';

void main(){
  Configuration.load();
  CurrentUser.setUserProfile(UserProfile(1, "Stacho", "email.com", "Stan jest super mega i ma super samochód"));
  runApp(MaterialApp(home: MyApp(),
    debugShowCheckedModeBanner: false,
    theme: ThemeData(primaryColor: Colors.lightBlue),));
}


class MyApp extends StatefulWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> {
  @override
  Widget build(BuildContext context) {
    return MainPageBodyLayout();
  }
}
