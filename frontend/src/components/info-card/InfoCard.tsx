import { InfoCardProps } from './info-card-props';

const InfoCard: React.FC<InfoCardProps> = ({ children, size, className }) => {
  const proportion = {
    lg: 'items-center max-w-[82.5%] h-[200px] md:h-[270px] md:pr-[10px] sm:pl-[5px] md:pl-[20px] xl:pl-[0] xl:h-[327px]',
    sm: 'items-center sm:w-[49%] h-[200px] md:h-[282px] xl:h-[339px] sm:pl-[5px] md:pl-[15px] xl:pl-[52px]',
  };

  return (
    <div
      className={`flex flex-col rounded-[30px] bg-white drop-shadow-md border-[1px] py-[40px] md:py-[74px] m-auto ${proportion[size]} ${className}`}
    >
      {children}
    </div>
  );
};

export default InfoCard;
