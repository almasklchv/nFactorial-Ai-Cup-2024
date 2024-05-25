import Hero from './components/Hero';
import Features from './components/Features';
import SubscriptionPlans from './components/SubscriptionPlans';
import { BurgerMenu } from '@/components/burger-menu';

const Home = () => {
  return (
    <>
      <BurgerMenu />
      <Hero />
      <Features />
      <SubscriptionPlans />
    </>
  );
};

export default Home;
