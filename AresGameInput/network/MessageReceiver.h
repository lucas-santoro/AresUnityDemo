
#pragma once
#include <functional>
#include <netinet/in.h>
#include <unistd.h>
#include <thread>
#include <atomic>
#include <string>
#include <cstring>
#include <iostream>

class MessageReceiver {
public:
    using Callback = std::function<void(const std::string&)>;

    MessageReceiver(int port, Callback cb);
    ~MessageReceiver();

    void start();
    void stop();

private:
    int port;
    int sockfd;
    std::atomic<bool> running{false};
    std::thread recvThread;
    Callback callback;

    void receiveLoop();
};
