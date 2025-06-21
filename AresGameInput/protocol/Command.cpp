#include "Command.h"

std::string CommandTypeToString(CommandType cmd) {
    switch (cmd) {
        case CommandType::MOVE_FORWARD: return "MOVE_FORWARD";
        case CommandType::MOVE_BACKWARD: return "MOVE_BACKWARD";
        case CommandType::MOVE_LEFT: return "MOVE_LEFT";
        case CommandType::MOVE_RIGHT: return "MOVE_RIGHT";
        case CommandType::ROTATE_LEFT: return "ROTATE_LEFT";
        case CommandType::ROTATE_RIGHT: return "ROTATE_RIGHT";
        case CommandType::ELEVATE_UP: return "ELEVATE_UP";
        case CommandType::ELEVATE_DOWN: return "ELEVATE_DOWN";
        case CommandType::FIRE: return "FIRE";
        case CommandType::START: return "START";
        case CommandType::EXIT: return "EXIT";
        default: return "INVALID";
    }
}

CommandType ParseInputToCommand(char input) {
    switch (input) {
        case 'w': return CommandType::MOVE_FORWARD;
        case 's': return CommandType::MOVE_BACKWARD;
        case 'a': return CommandType::MOVE_LEFT;
        case 'd': return CommandType::MOVE_RIGHT;
        case 'q': return CommandType::ROTATE_LEFT;
        case 'e': return CommandType::ROTATE_RIGHT;
        case 'i': return CommandType::ELEVATE_UP;
        case 'k': return CommandType::ELEVATE_DOWN;
        case ' ': return CommandType::FIRE;
        case 'p': return CommandType::START;
        case 'v': return CommandType::EXIT;
        default:  return CommandType::INVALID;
    }
}
