import Switcher from '@/components/Switcher';
import { SubscriptionCard } from '@/components/subscription-card';
import { useState } from 'react';

const SubscriptionPlans = () => {
  const [billingPeriod, setBillingPeriod] = useState<'monthly' | 'annual'>(
    'monthly'
  );
  const [annual, setAnnual] = useState(false);

  const handlePeriodChange = () => {
    billingPeriod === 'monthly'
      ? setBillingPeriod('annual')
      : setBillingPeriod('monthly');
    setAnnual((prev) => !prev);
  };

  const setAnnualPeriod = () => {
    setBillingPeriod('annual');
    setAnnual(true);
  };

  return (
    <div id="pricing" className="flex flex-col items-center">
      <h2 className="text-[18px] sm:text-[27px] xl:text-[45px] mb-[42px]">
        Subscription Plans
      </h2>
      <span className="absolute right-0 z-0 bg-[url('./assets/images/right-triangle.png')] bg-cover md:w-[8rem] md:h-[20rem] xl:h-[30rem] xl:w-[13rem] hidden md:block" />
      <Switcher
        onSwitch={handlePeriodChange}
        isChange={annual}
        variants={['Monthly Billing', 'Annual Billing']}
        className="mb-[132px]"
      />
      <div className="subscriptions flex flex-wrap justify-center gap-[91px] mb-[290px]">
        <SubscriptionCard
          plan="Basic"
          price={0}
          isActive
          periodType="monthly"
          benefits={['10 tables/month']}
        />
        <SubscriptionCard
          plan="Pro"
          price={billingPeriod === 'monthly' ? 7 : 5.5}
          isActive={false}
          periodType={billingPeriod}
          benefits={['500 tables/month']}
          setAnnual={setAnnualPeriod}
        />
        <SubscriptionCard
          plan="Pro"
          price={billingPeriod === 'monthly' ? 27 : 21.5}
          isActive={false}
          periodType={billingPeriod}
          benefits={['2000 tables/month']}
          setAnnual={setAnnualPeriod}
        />
        <SubscriptionCard
          isCustom
          plan="Basic"
          price={0}
          isActive={false}
          periodType="monthly"
          benefits={['Custom table amounts']}
        />
      </div>
    </div>
  );
};

export default SubscriptionPlans;
