import React from 'react';

interface SwitcherProps {
  className?: string;
  onSwitch: () => void;
  variants: string[];
  isChange: boolean;
}

const Switcher: React.FC<SwitcherProps> = ({
  className,
  onSwitch,
  variants,
  isChange,
}) => {
  const colorM = isChange ? 'text-white' : 'text-primary';
  const colorA = isChange ? 'text-primary' : 'text-white';

  const bgColorM = isChange ? 'bg-white' : 'bg-primary';
  const bgColorA = isChange ? 'bg-primary' : 'bg-white';

  const handlePeriodChange = () => {
    onSwitch();
  };
  return (
    <div
      className={`${className} flex md:max-w-[400px] xl:max-w-[574px] bg-primary rounded-[20px]`}
    >
      <div
        onClick={handlePeriodChange}
        className={`shadow-md text-[12px] sm:text-[15px] md:text-[18px] xl:text-[25px] text-center transition-all duration-300 md:w-[200px] xl:w-[287px]   rounded-[20px] ${bgColorA} py-[10px] sm:py-[15px] md:py-[20px] xl:py-[31px] px-[10px] sm:px-[20px] md:px-[40px] xl:px-[60px] cursor-pointer  ${colorM}`}
      >
        {variants[0]}
      </div>
      <div
        onClick={handlePeriodChange}
        className={`shadow-md text-[12px] sm:text-[15px] md:text-[18px] xl:text-[25px] text-center transition-all duration-300 md:w-[200px] xl:w-[287px]  rounded-[20px] ${bgColorM} py-[10px] sm:py-[15px] md:py-[20px] xl:py-[31px] px-[15px] sm:px-[20px] md-px-[40px] xl:px-[60px] cursor-pointer ${colorA} `}
      >
        {variants[1]}
      </div>
    </div>
  );
};

export default Switcher;
