
import 'package:flutter/material.dart';

import '../models/UserProfile.dart';

class UserProfileLayout {

  Widget getProfile(UserProfile userProfile) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(userProfile.userName,
          textAlign: TextAlign.left,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 20,
          ),
        ),
        Text(userProfile.userName,
            textAlign: TextAlign.left),
        Text(userProfile.bio,
            textAlign: TextAlign.left),
      ],
    );
  }
}