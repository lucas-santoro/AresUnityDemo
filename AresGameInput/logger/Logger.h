#pragma once
#include <string>
#include <fstream>
#include <chrono>
#include <iomanip>
#include <sstream>
#include <filesystem>

class Logger {
public:
    Logger();
    ~Logger();

    void log(const std::string &message);

private:
    std::ofstream file;
    std::string generateFilename();
    std::string currentTimestamp();
};
