import React from 'react';
import logo from '../../assets/icons/logo.svg';

interface HeaderProps {}

const Header: React.FC<HeaderProps> = ({}) => {
  return (
    <header className="flex justify-between m-10 z-10">
      <a href="/">
        <img src={logo} alt="logo" />
      </a>
      <nav className="hidden sm:flex sm:gap-5 xl:gap-10 items-center  ">
        <a className="md:text-[14px] xl:text-[17px] md:text-white" href="/">
          Home
        </a>
        <a
          className="md:text-[14px] xl:text-[17px] md:text-white"
          href="#features"
        >
          Who we are
        </a>
        <a
          className="md:text-[14px] xl:text-[17px] md:text-white"
          href="#pricing"
        >
          Pricing
        </a>
        <button className="text-white md:text-primary md:h-[40px] xl:w-121 xl:h-37  md:text-[15px] xl:text-[18px] cursor-pointer md:ml-5 xl:ml-10 font-semibold sm:py-[5px] xl:py-[8px] px-[15px] md:px-[20px] xl:px-[24px] text-base rounded-[33px] bg-primary md:bg-white">
          SIGN UP
        </button>
      </nav>
    </header>
  );
};

export default Header;
