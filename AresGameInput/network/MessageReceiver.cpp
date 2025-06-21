#include "MessageReceiver.h"

MessageReceiver::MessageReceiver(int port, Callback cb)
    : port(port), callback(cb) {}

MessageReceiver::~MessageReceiver() {
    stop();
}

void MessageReceiver::start() {
    running = true;
    recvThread = std::thread(&MessageReceiver::receiveLoop, this);
}

void MessageReceiver::stop() {
    running = false;
    if (recvThread.joinable())
        recvThread.join();
}

void MessageReceiver::receiveLoop() {
    sockfd = socket(AF_INET, SOCK_DGRAM, 0);
    sockaddr_in addr{};
    addr.sin_family = AF_INET;
    addr.sin_port = htons(port);
    addr.sin_addr.s_addr = INADDR_ANY;

    bind(sockfd, (struct sockaddr*)&addr, sizeof(addr));

    char buffer[1024];
    while (running) {
        sockaddr_in srcAddr;
        socklen_t addrLen = sizeof(srcAddr);
        int len = recvfrom(sockfd, buffer, sizeof(buffer) - 1, 0, (sockaddr*)&srcAddr, &addrLen);
        if (len > 0) {
            buffer[len] = '\0';
            std::string msg(buffer);
            callback(msg);
        }
    }

    close(sockfd);
}
