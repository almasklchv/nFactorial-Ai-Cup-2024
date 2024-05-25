import React from 'react';
import logo from '../../assets/icons/logo.svg';
import { Link } from 'react-router-dom';

interface HeaderProps {
  linksColor: string;
  buttonColor?: string;
  buttonBg?: string;
  button?: boolean;
}

const Header: React.FC<HeaderProps> = ({
  linksColor,
  buttonBg,
  buttonColor,
  button,
}) => {
  return (
    <header className="flex justify-between m-10 z-10">
      <a href="/">
        <img src={logo} alt="logo" />
      </a>
      <nav className="hidden md:flex sm:gap-5 xl:gap-10 items-center">
        <a
          className="md:text-[14px] xl:text-[17px] md:text-white"
          href="/"
          style={{ color: linksColor }}
        >
          Home
        </a>
        <a
          className="md:text-[14px] xl:text-[17px] md:text-white"
          href="#features"
          style={{ color: linksColor }}
        >
          Who we are
        </a>
        <a
          className="md:text-[14px] xl:text-[17px] md:text-white"
          href="#pricing"
          style={{ color: linksColor }}
        >
          Pricing
        </a>
        {button && (
          <button
            style={{ background: buttonBg, color: buttonColor }}
            className="text-white md:text-primary md:h-[40px] xl:w-121 xl:h-37  md:text-[15px] xl:text-[18px] cursor-pointer md:ml-5 xl:ml-10 font-semibold sm:py-[5px] xl:py-[8px] px-[15px] md:px-[20px] xl:px-[24px] text-base rounded-[33px] bg-primary md:bg-white"
          >
            <Link to={'/generate'}>GET STARTED</Link>
          </button>
        )}
      </nav>
    </header>
  );
};

export default Header;
