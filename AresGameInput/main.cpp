#include <iostream>
#include <thread>
#include <atomic>
#include "core/InputHandler.h"
#include "protocol/Command.h"
#include "network/MessageSender.h"
#include "network/MessageReceiver.h"
#include "logger/Logger.h"

std::atomic<bool> gameOver = false;

void handleStats(const std::string& message)
{
    gameOver = true;
    Logger logger;
    std::cout << "[STATS] " << message << "\n";
    logger.log("[STATS] " + message);
}

int main()
{
    InputHandler input;
    MessageSender sender("127.0.0.1", 9000);
    MessageReceiver receiver(8089, handleStats);
    Logger logger;

    receiver.start();

    std::cout << "=== AresGameInput - Terminal Controller ===\n";
    std::cout << "[w/a/s/d] move | [q/e] rotate | [i/k] elevate | [space] fire | [p] start | [v] quit\n";

    while (!gameOver) {
        CommandType cmd = input.getNextCommand();

        if (gameOver) break;

        std::string cmdStr = CommandTypeToString(cmd);

        if (cmd == CommandType::INVALID) continue;

        std::cout << "Command: " << cmdStr << "\n";
        sender.send(cmdStr + "\n");
        logger.log(cmdStr);

        if (cmd == CommandType::EXIT)
            gameOver = true;
    }

    receiver.stop();
    return 0;
}
