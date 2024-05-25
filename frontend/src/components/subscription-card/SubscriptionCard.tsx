import React from 'react';
import { Button } from '../ui/button';
import TickIcon from '../../assets/icons/tick.svg';
import { Separator } from '../ui/separator';
import { SubscriptionCardProps } from './subscription-card-props';

const SubscriptionCard: React.FC<SubscriptionCardProps> = ({
  plan,
  price,
  isActive,
  periodType,
  isCustom,
  benefits,
  className,
  setAnnual,
}) => {
  //   {/* {`${tableAmount} tables/${periodType === 'monthly' ? 'month' : 'year'}`} */}

  return (
    <div
      className={`${className} flex flex-col w-[80%] sm:w-[486px] h-[450px] sm:h-[631px] mb-[-50px] md:mb-0 border rounded-2xl py-10 px-12`}
    >
      <div
        className={
          `text-[20px] sm:text-[25px] md:text-[30px] xl:text-[35px] font-bold` +
          (isCustom && ' mb-[43px]')
        }
      >
        {isCustom ? 'Need more?' : `${plan} Plan`}
      </div>
      <div className="md:mt-[7px] xl:mt-[13px] text-[20px] sm:text-[27px] md:text-[35px] xl:text-[40px] font-normal ">
        {plan === 'Basic' ? (
          `${!isCustom ? 'Free' : ''}`
        ) : (
          <div className="flex">
            <span className="text-black font-lato text-[23px] md:text-[30px] xl:text-40 font-light">
              ${price}
            </span>
            <span className="text-gray-600 font-lato text-[23px] md:text-[30px] xl:text-25 ">
              / month
            </span>
          </div>
        )}
      </div>
      {plan !== 'Basic' && (
        <span className="mt-19 text-black font-lato text-20 font-light ">
          {periodType === 'monthly' ? 'Billed monthly' : 'Billed yearly'}
        </span>
      )}
      {isActive ? (
        <Button className="w-395 h-53 mt-[65px] mb-[43px] bg-white text-primary rounded-10 border border-solid border-black border-opacity-50">
          Active
        </Button>
      ) : (
        <Button className="w-395 h-53  mt-[45px]  ">
          {isCustom ? 'Contact us' : 'Subscribe'}
        </Button>
      )}
      {isActive || isCustom ? (
        ''
      ) : (
        <a
          onClick={setAnnual}
          className="mt-[15px] text-[12px] sm:text-[16px] text-primary cursor-pointer self-center"
        >
          Save with annual billing (20% off)
        </a>
      )}
      <Separator className="mb-[43px] mt-[40px]" />

      <div className="  flex flex-col  gap-y-2.5">
        {benefits.map((string) => {
          return (
            <div className="flex gap-x-2" key={string}>
              <img
                src={TickIcon}
                alt="TickIcon"
                className="q-[20px] sm:w-[25px] h-[20px] sm:h-[25px]"
              />
              <div className="text-[14px] sm:text-[16px]">{string}</div>
            </div>
          );
        })}
      </div>
    </div>
  );
};

export default SubscriptionCard;
