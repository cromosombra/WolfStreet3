
public class Transaction
{
    public static void Transact(Participant seller, Participant buyer, Company comp, int amnt)
    {
        var sellerblock = seller.shares[comp.pName];

        var transactionValue = amnt * comp.value;
        if (sellerblock.shareQuantity >= amnt && buyer.money >= transactionValue)
        {
            seller.money += transactionValue;
            buyer.money -= transactionValue;

            if (!buyer.shares.ContainsKey(comp.pName))
            {
                var buyerblock = sellerblock;
                buyerblock.shareQuantity = amnt;
                buyer.shares.Add(comp.pName, buyerblock);
            }
            else
                buyer.shares[comp.pName].shareQuantity += amnt;

            sellerblock.shareQuantity -= amnt;

            if (sellerblock.shareQuantity <= 0)
            {
                seller.shares.Remove(comp.pName);
            }
        }
        else
            return;

    }
}
