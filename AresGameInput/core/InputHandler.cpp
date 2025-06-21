#include "InputHandler.h"
#include <termios.h>
#include <cstdio> 
#include <unistd.h>

char getCharWithoutEnter() {
    termios oldt, newt;
    char ch;
    tcgetattr(STDIN_FILENO, &oldt);
    newt = oldt;
    newt.c_lflag &= ~(ICANON | ECHO);
    tcsetattr(STDIN_FILENO, TCSANOW, &newt);
    ch = getchar();
    tcsetattr(STDIN_FILENO, TCSANOW, &oldt);
    return ch;
}

CommandType InputHandler::getNextCommand() {
    char input = getCharWithoutEnter();
    return ParseInputToCommand(input);
}
