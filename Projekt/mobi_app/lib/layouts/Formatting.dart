
import 'package:flutter/material.dart';

class Formatting {
  static String getDate(DateTime date) {
    return "${date.day}/${date.month}/${date.year} ${date.hour}:${date.minute}";
  }

  static Container getContainerFormatting(Widget child) {
    return Container(
      decoration: BoxDecoration(
          border: Border.all(
            color: const Color(0xff255e9b),
            width: 3,
          ),
          borderRadius: BorderRadius.circular(12),
          color: const Color(0xff9fb4ca)
      ),
      margin: const EdgeInsets.all(8),
      padding: const EdgeInsets.all(8),
      child: child,
    );
  }
}