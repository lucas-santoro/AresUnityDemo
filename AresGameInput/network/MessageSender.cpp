#include "MessageSender.h"

MessageSender::MessageSender(const std::string &ip, int port) {
    sockfd = socket(AF_INET, SOCK_DGRAM, 0);
    if (sockfd < 0) {
        std::cerr << "Failed to create UDP socket\n";
        return;
    }

    memset(&serverAddr, 0, sizeof(serverAddr));
    serverAddr.sin_family = AF_INET;
    serverAddr.sin_port = htons(port);

    if (inet_pton(AF_INET, ip.c_str(), &serverAddr.sin_addr) <= 0) {
        std::cerr << "Invalid IP address\n";
        close(sockfd);
        sockfd = -1;
    }
}

MessageSender::~MessageSender() {
    if (sockfd >= 0) close(sockfd);
}

bool MessageSender::send(const std::string &message) {
    if (sockfd < 0) return false;

    ssize_t sent = sendto(sockfd, message.c_str(), message.size(), 0,
                          (struct sockaddr*)&serverAddr, sizeof(serverAddr));

    return sent == (ssize_t)message.size();
}
