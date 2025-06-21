cmake_minimum_required(VERSION 3.10)
project(AresGameInput)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

include_directories(core protocol)

add_executable(AresGameInput
    main.cpp
    core/InputHandler.cpp
    protocol/Command.cpp
    network/MessageSender.cpp
    network/MessageReceiver.cpp
    logger/Logger.cpp
)
