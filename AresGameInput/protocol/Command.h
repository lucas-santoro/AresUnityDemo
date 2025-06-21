#pragma once
#include <string>

enum class CommandType {
    MOVE_FORWARD,
    MOVE_BACKWARD,
    MOVE_LEFT,
    MOVE_RIGHT,
    ROTATE_LEFT,
    ROTATE_RIGHT,
    ELEVATE_UP,
    ELEVATE_DOWN,
    FIRE,
    START,
    EXIT,
    INVALID
};

std::string CommandTypeToString(CommandType cmd);
CommandType ParseInputToCommand(char input);
