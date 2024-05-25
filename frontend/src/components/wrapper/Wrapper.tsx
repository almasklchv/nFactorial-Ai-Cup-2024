import { WrapperProps } from './wrapper-props';

const Wrapper: React.FC<WrapperProps> = ({ children }) => {
  return <div className="flex flex-col">{children}</div>;
};

export default Wrapper;
