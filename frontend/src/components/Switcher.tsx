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
      className={`flex max-w-[350px] bg-primary rounded-[10px] ${className}`}
    >
      <div
        onClick={handlePeriodChange}
        className={`shadow-md text-[10px] sm:text-[12px] md:text-[14px] text-center transition-all duration-300 w-[200px] rounded-[10px] ${bgColorA} py-[5px] sm:py-[10px] px-[10px] cursor-pointer ${colorM}`}
      >
        {variants[0]}
      </div>
      <div
        onClick={handlePeriodChange}
        className={`shadow-md text-[10px] sm:text-[12px] md:text-[14px] text-center transition-all duration-300 w-[200px] rounded-[10px] ${bgColorM} py-[5px] sm:py-[10px] px-[10px] cursor-pointer ${colorA}`}
      >
        {variants[1]}
      </div>
    </div>
  );
};

export default Switcher;
