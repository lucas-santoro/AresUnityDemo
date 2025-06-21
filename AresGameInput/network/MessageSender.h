#pragma once
#include <arpa/inet.h>
#include <unistd.h>
#include <cstring>
#include <iostream>
#include <string>

class MessageSender {
public:
    MessageSender(const std::string& ip, int port);
    ~MessageSender();

    bool send(const std::string& message);

private:
    int sockfd;
    struct sockaddr_in serverAddr;
};
