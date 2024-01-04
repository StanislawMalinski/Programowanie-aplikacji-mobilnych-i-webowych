
import '../models/Post.dart';
import 'package:flutter/material.dart';

import '../services/CurrentUser.dart';
import 'Formatting.dart';

class PostLayout {

  static Widget getPost(Post post) {
    var child = Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(post.title,
          textAlign: TextAlign.left,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 20,
          ),
        ),
        InkWell(
          onTap: () {print("Chuj ci w dupe");},
          child: Row(
              children: [
                const  Icon(Icons.person),
                Text(post.user.userName,
                    textAlign: TextAlign.left),
                ],
            ),
        ),
        Text(Formatting.getDate(post.createdAt),
            textAlign: TextAlign.left),
        Text(post.content,
            textAlign: TextAlign.left),
        getButtonsIfOwner(post),
      ],
    );
    return Formatting.getContainerFormatting(child);
  }

  static Widget getButtonsIfOwner(Post post) {
    if (post.user.id == CurrentUser.getId()) {
      return Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          IconButton(
              icon: const Icon(Icons.edit),
              tooltip: 'Edit',
              onPressed: () {}),
          IconButton(
              icon: const Icon(Icons.delete),
              tooltip: 'Delete',
              onPressed: () {}),
        ],
      );
    }
    return Container();
  }
}