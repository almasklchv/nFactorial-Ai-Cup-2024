import { InfoCard } from '@/components/info-card';

const Features = () => {
  return (
    <div id="features" className="features mb-[100px]">
      <span className="absolute left-0 z-0 bg-[url('./assets/images/left-triangle.png')] bg-cover w-[5.5rem] h-[50rem] hidden md:block" />
      <InfoCard size="lg" className="mb-[15px] pl-[10px] sm:pl-[5px]">
        <h3 className="pb-[15px] md:pb-[30px] sm:text-[16.5px] md:text-[18.5px] xl:text-[26px] font-semibold">
          Real-Time Data Automation
        </h3>
        <p className="md:text-[16px] xl:text-[23px]">
          Our innovative AI analyzes your images and creates precise
          spreadsheets in seconds.
        </p>
        <img
          className="absolute bottom-0 left-1/2 transform -translate-x-1/2"
          src="/src/assets/images/sheets.png"
          alt="sheets image"
          width={'70%'}
        />
      </InfoCard>
      <div className="sm:flex justify-between m-auto max-w-[82.5%]">
        <InfoCard size="sm" className="pl-[10px] sm:pl-0">
          <h3 className="pb-[15px] md:pb-[30px] sm:text-[16.5px] md:text-[18.5px] xl:text-[26px] font-semibold">
            Precision in Every Number
          </h3>
          <p className="md:text-[16px] xl:text-[23px]">
            Our tech ensures accurate data capture, free from manual errors.
          </p>
          <img
            className="absolute bottom-0 left-1/2 transform -translate-x-1/2 w-2/5 sm:w-3/5"
            src="/src/assets/images/sheets-sm.png"
            alt="sheets image"
          />
        </InfoCard>
        <InfoCard
          size="sm"
          className="pl-[10px] sm:pl-0 sm:pr-[5px] md:pr-[15px] xl:pr-[54px]"
        >
          <h3 className="pb-[15px] md:pb-[30px] sm:text-[16.5px] md:text-[18.5px] xl:text-[26px] font-semibold sm:text-right">
            Streamline Your Data Workflow
          </h3>
          <p className="md:text-[16px] xl:text-[23px] sm:text-right">
            Automate spreadsheet creation to boost productivity effortlessly.
          </p>
          <img
            className="absolute bottom-0 left-1/2 transform -translate-x-1/2 w-2/5 sm:w-3/5"
            src="/src/assets/images/sheets-sm.png"
            alt="sheets image"
          />
        </InfoCard>
      </div>
    </div>
  );
};

export default Features;
