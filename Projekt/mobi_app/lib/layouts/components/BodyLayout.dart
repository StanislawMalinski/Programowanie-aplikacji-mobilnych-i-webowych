import 'package:flutter/material.dart';

import '../PostLayout.dart';
import 'BottomNavigationBarComponent.dart';

class BodyLayout<T> extends StatefulWidget {
  @override
  BodyLayoutState<T> createState() => BodyLayoutState<T>();
}

class BodyLayoutState<T> extends State<BodyLayout> {
  int page = 1;
  int maxPage = 2; // TODO replace with dynamic value
  String title = "ForFace";
  List<T> elements = [];

  @override
  Widget build(BuildContext context) {
    setState(() {
      maxPage = getMaxPage();
    });

    if (elements.isEmpty) {
      _loadElements(page++);
    }

    var controller = ScrollController();
    controller.addListener(() {
      if (controller.position.atEdge) {
        if (controller.position.pixels != 0) {
          setState(() {
            if (page <= maxPage) {
              _loadElements(page++);
            }
          });
        }
      }
    });

    var csv =CustomScrollView(
      scrollDirection: Axis.vertical,
      controller: controller,
      slivers: [
        SliverList(
          delegate: SliverChildBuilderDelegate(
                (context, index) {
              return getWidget(elements[index]);
            },
            childCount: elements.length,
          ),
        ),
      ],
    );
    return Scaffold(
      appBar: AppBar(
        title: Text(title),
      ),
      body: csv,
      bottomNavigationBar: const BottomNavigationComponent(),
    );
  }

  void _loadElements(int page) async {
    loadElements(page)
        .then((value) =>
        setState(() {
          elements.addAll(value);
        }));
  }

  Future<List<T>> loadElements(int page) async {
    return [];
  }

  Widget getWidget(T element) {
    return Text("Not implemented");
  }

  int getMaxPage() => 1;

  void setTitle(String title){
    setState(() {
      this.title = title;
    });
  }
}