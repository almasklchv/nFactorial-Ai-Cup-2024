import Hero from './components/Hero';
import Features from './components/Features';
import SubscriptionPlans from './components/SubscriptionPlans';
import { Wrapper } from '@/components/wrapper';
import { Header } from '@/components/header';
import { Footer } from '@/components/footer';

const Home = () => {
  return (
    <Wrapper>
      <Header linksColor='#fff' buttonBg='#fff' buttonColor='107C41'/> 
      <Hero />
      <Features />
      <SubscriptionPlans />
      <Footer />
    </Wrapper>
  );
};

export default Home;
