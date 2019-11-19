-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Máy chủ: localhost
-- Thời gian đã tạo: Th10 14, 2019 lúc 02:59 PM
-- Phiên bản máy phục vụ: 8.0.13-4
-- Phiên bản PHP: 7.2.24-0ubuntu0.18.04.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `cxraewXGVj`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Category`
--

CREATE TABLE `Category` (
  `CategoryId` int(11) NOT NULL,
  `CategorySiteId` text COLLATE utf8_vietnamese_ci NOT NULL,
  `CategoryName` text COLLATE utf8_vietnamese_ci,
  `SiteId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Product`
--

CREATE TABLE `Product` (
  `Id` bigint(20) NOT NULL,
  `ProductId` varchar(50) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `Name` text COLLATE utf8_vietnamese_ci,
  `Price` float DEFAULT NULL,
  `CreatedDate` varchar(20) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `Quantity` int(7) DEFAULT NULL,
  `CategoryId` varchar(100) COLLATE utf8_vietnamese_ci DEFAULT NULL,
  `QuantitySold` int(7) DEFAULT NULL,
  `CommentCount` bigint(10) DEFAULT NULL,
  `Discount` float DEFAULT NULL,
  `VariableJson` text COLLATE utf8_vietnamese_ci,
  `Url` text COLLATE utf8_vietnamese_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Site`
--

CREATE TABLE `Site` (
  `SiteId` int(11) NOT NULL,
  `SiteName` text COLLATE utf8_vietnamese_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `Site`
--

INSERT INTO `Site` (`SiteId`, `SiteName`) VALUES
(1, 'Shopee'),
(2, 'Lazada'),
(3, 'Tiki'),
(4, 'Sendo');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `User`
--

CREATE TABLE `User` (
  `Id` varchar(36) CHARACTER SET utf8 COLLATE utf8_vietnamese_ci NOT NULL,
  `UserName` varchar(50) COLLATE utf8_vietnamese_ci NOT NULL,
  `FirstName` varchar(50) COLLATE utf8_vietnamese_ci NOT NULL,
  `LastName` varchar(50) COLLATE utf8_vietnamese_ci NOT NULL,
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0',
  `CreatedDate` date NOT NULL,
  `UpdatedDate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_vietnamese_ci;

--
-- Đang đổ dữ liệu cho bảng `User`
--

INSERT INTO `User` (`Id`, `UserName`, `FirstName`, `LastName`, `IsDeleted`, `CreatedDate`, `UpdatedDate`) VALUES
('e1c1bdf9-de4e-46e4-af2d-5326a2ac3e2e', 'admin', 'Admin', 'dmin', b'0', '2019-11-14', NULL);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `Category`
--
ALTER TABLE `Category`
  ADD PRIMARY KEY (`CategoryId`);

--
-- Chỉ mục cho bảng `Product`
--
ALTER TABLE `Product`
  ADD PRIMARY KEY (`Id`);

--
-- Chỉ mục cho bảng `Site`
--
ALTER TABLE `Site`
  ADD PRIMARY KEY (`SiteId`);

--
-- Chỉ mục cho bảng `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `Category`
--
ALTER TABLE `Category`
  MODIFY `CategoryId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `Product`
--
ALTER TABLE `Product`
  MODIFY `Id` bigint(20) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `Site`
--
ALTER TABLE `Site`
  MODIFY `SiteId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
