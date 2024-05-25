import logo from '../../assets/icons/light-logo.svg';

const Footer = () => {
  const links = [
    { name: 'Home', route: '/' },
    { name: 'Who we are', route: '#features' },
    { name: 'Pricing', route: '#pricing' },
    { name: 'Privacy Policy', route: '/privacy' },
    { name: 'Terms of Use', route: '/terms' },
  ];

  // absolute

  return (
    <footer className="flex flex-col sm:flex-row justify-between items-center bg-primary px-4 md:px-6 xl:px-14 py-3 md:py-3 xl:py-4 bottom-0 w-full">
      <a href="/">
        <img
          src={logo}
          alt="logo"
          className="w-[118px] md:w-[148px] xl:w-[198px]"
        />
      </a>
      <div className="mb-[5px] sm:mb-0">
        {links.map((link) => (
          <a
            className="text-white text-[10px] md:text-[12px] xl:text-base mr-3.5"
            key={link.name}
            href={link.route}
          >
            {link.name}
          </a>
        ))}
      </div>
      <p className="text-white text-[10px] md:text-[12px] xl:text-base">
        Copyright © 2024. All rights reserved.
      </p>
    </footer>
  );
};

export default Footer;
