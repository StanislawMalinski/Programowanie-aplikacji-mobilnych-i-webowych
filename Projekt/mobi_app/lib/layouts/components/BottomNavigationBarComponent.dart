
import 'package:flutter/material.dart';

import '../../models/Post.dart';
import '../../models/UserProfile.dart';
import '../MainPageBodyLayout.dart';
import '../UserProfileBodyLayout.dart';
import '../PostEditorLayout.dart';

class BottomNavigationComponent extends StatefulWidget {
  const BottomNavigationComponent({super.key});

  @override
  _BottomNavigationComponentState createState() =>
      _BottomNavigationComponentState();
}

class _BottomNavigationComponentState extends State<BottomNavigationComponent> {
  int _selected_tab = 0;
  Post _selected_post = Post(-1, "", "", DateTime.now(), UserProfile(-1, "", "", ""), []);

  List<Widget> tabs = [
    MainPageBodyLayout(),
    MyProfileBodyLayout(),
    PostEditorBodyLayout(),
  ];

  void _setTab(int index) {
    setState(() {
      _selected_tab = index;
      var tab = tabs[_selected_tab];
      if (index == 0) {
       while(Navigator.canPop(context)) {
         Navigator.pop(context);
       }
      }
        Navigator.push(context, MaterialPageRoute(builder: (context) => tab));
    });
  }

  @override
  Widget build(BuildContext context) {
    return BottomNavigationBar(
        selectedItemColor: Colors.grey,
        onTap: (index) => _setTab(index),
        items: const [
          BottomNavigationBarItem(
            icon: Icon(Icons.home, color: Colors.grey),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.face, color: Colors.grey,),
            label: 'MyProfile',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.add, color: Colors.grey),
            label: 'New Post',
          )
        ],
    );
  }
}