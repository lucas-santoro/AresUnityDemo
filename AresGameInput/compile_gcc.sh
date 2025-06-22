#!/bin/bash
set -e
cd "$(dirname "$0")"
mkdir -p build
g++ -std=c++17 -O2 \
    -Icore -Iprotocol -Inetwork -Ilogger \
    main.cpp \
    core/InputHandler.cpp \
    protocol/Command.cpp \
    network/MessageSender.cpp \
    network/MessageReceiver.cpp \
    logger/Logger.cpp \
    -o build/AresGameInput
./build/AresGameInput
