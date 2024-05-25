import { Button } from '@/components/ui/button';

const Hero = () => {
  return (
    <>
      <span className="absolute right-0 top-0 z-0 bg-[url('./assets/images/top-triangle.png')] md:w-[38rem] md:h-[49rem] xl:w-[45rem] xl:h-[57rem] hidden md:block" />
      <div className="hero flex items-center md:justify-between justify-center md:px-20 xl:px-40 mt-16 z-10 mb-[220px]">
        <div>
          <h1 className="text-[20px] sm:text-[30px] md:text-[25px] xl:text-[40px] 2xl:text-[55px] mb-2 sm:mb-5">
            Tired of making tables?
            <br />
            We will do it for you in 1 minute
          </h1>
          <div className="flex items-center">
            <p className="text-[15px] sm:text-[20px] md:text-[15px] xl:text-[25px] 2xl:text-[35px] opacity-65 mr-5 sm:mr-10">
              Are you interested?
            </p>
            <Button className="font-bold text-[8.4px] md:text-[10.4px] xl:text-[18.4px] 2xl:text-[22.4px] rounded-[26px] h-[25px] md:w-[70px] md:h-[30px] xl:w-[28%] xl:h-[40px] 2xl:h-[50px] 2xl:w-[20%]">
              SIGN UP
            </Button>
          </div>
        </div>
        <span className="bg-[url('./assets/images/laptop.png')] bg-cover md:min-w-[305px] md:h-[230px] xl:min-w-[450px] xl:h-[300px] 2xl:min-w-[600px] 2xl:h-[420px] z-10"></span>
      </div>
    </>
  );
};

export default Hero;
