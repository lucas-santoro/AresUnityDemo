#include "Logger.h"
#include <filesystem>

Logger::Logger() {
    createLogsDirectory();
    
    std::string filename = generateFilename();
    file.open(filename, std::ios::out);
}

Logger::~Logger() {
    if (file.is_open()) file.close();
}

void Logger::log(const std::string& message) {
    if (!file.is_open()) return;
    file << currentTimestamp() << " - " << message << "\n";
    file.flush();
}

void Logger::createLogsDirectory() {
    try {
        std::filesystem::create_directory("logs");
    } catch (const std::filesystem::filesystem_error& e) {}
}

std::string Logger::generateFilename() {
    auto t = std::chrono::system_clock::now();
    auto tt = std::chrono::system_clock::to_time_t(t);
    std::tm tm = *std::localtime(&tt);
    
    std::ostringstream oss;
    oss << "logs/log_"
        << std::put_time(&tm, "%Y-%m-%d_%H-%M-%S")
        << ".txt";
    return oss.str();
}

std::string Logger::currentTimestamp() {
    auto now = std::chrono::system_clock::now();
    auto tt = std::chrono::system_clock::to_time_t(now);
    std::tm tm = *std::localtime(&tt);
    
    std::ostringstream oss;
    oss << std::put_time(&tm, "%Y-%m-%d %H:%M:%S");
    return oss.str();
}