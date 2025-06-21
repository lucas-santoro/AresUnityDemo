#pragma once
#include "../protocol/Command.h"

class InputHandler {
public:
    CommandType getNextCommand();
};
