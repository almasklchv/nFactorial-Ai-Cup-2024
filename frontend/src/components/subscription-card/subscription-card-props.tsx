export interface SubscriptionCardProps {
  plan: string;
  price: number;
  isActive: boolean;
  isCustom?: boolean;
  periodType: 'monthly' | 'annual';
  benefits: string[];
  className?: string;
  setAnnual?: () => void;
}
